
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Block
    {
        /// <summary>
        /// Block constructor used when creating a genesis block.
        /// </summary>
        public Block()
        {
            timestamp = DateTime.Now;
            index = 0;
            previousHash = String.Empty;
            transactionList = new List<Transaction>();
            
            // Calls mine hash.
            mineHash();

            Blockchain.incrementTotalBlockTime(blockTime);
        }

        /// <summary>
        /// Constructor for the block.
        /// </summary>
        /// <param name="lastBlock">The last block in the chain.</param>
        /// <param name="transactions">Transactions to be stored in the block.</param>
        /// <param name="minerAddress">Miner's address.</param>
        public Block(Block lastBlock, List<Transaction> transactions, String minerAddress)
        {
            // When the block was created.
            timestamp = DateTime.Now;

            // Index of the block.
            index = lastBlock.getIndex() + 1;

            // Previous hash.
            previousHash = lastBlock.getHash();

            // The wallet to be credited the reward for the mining effort.
            this.minerAddress = minerAddress;

            // Assign a simple fixed value reward
            reward = 1.0;

            // Create and append the reward transaction
            transactions.Add(createRewardTransaction(transactions));

            // Assign provided transactions to the block
            transactionList = new List<Transaction>(transactions);

            // Calculate the merkle root of the blocks transactions
            merkleRoot = MerkleRoot(transactionList);

            // If dynamic difficulty is enabled.            
            if (BlockchainApp.getDynamicDifficulty() == true)
            {
                // If the block time of the last block was shorter than expected...
                if (lastBlock.getBlockTime() < (Blockchain.getTotalBlockTime() / (lastBlock.getIndex() + 1)) * 0.125)
                {
                    // Set difficulty to 5.
                    difficulty = 5;
                }

                // If the block time of the last block was longer than expected...
                else if (lastBlock.getBlockTime() > (Blockchain.getTotalBlockTime() / (lastBlock.getIndex() + 1)) * 1.25)
                {
                    // Set difficulty to 3.
                    difficulty = 3;

                }

                // Otherwise set the difficulty to 4.
                else
                {
                    // Set difficulty to 4.
                    difficulty = 4;
                }
            }

            // Start to initialise hash. 
            mineHash();

            // Adjust total block time.
            Blockchain.incrementTotalBlockTime(blockTime);
        }

        // Time at which the block was created.
        private DateTime timestamp;

        // Index position of block in the blockchain.
        private int index;

        private int difficulty = 4;

        // Hash value of the block.
        private String hash;

        // Hash value of the previous block.
        private String previousHash;

        private String merkleRoot;

        private String minerAddress;

        // Number only used once (nonce) used to solve the proof-of-work puzzle.
        private long nonce;

        // e-nonce for threading.
        private long eNonceEven;

        // e-nonce for threading.
        private long eNonceOdd;

        private String hashEven = String.Empty;

        private String hashOdd = String.Empty;

        // Rewards
        // Simple fixed reward established by "Coinbase"
        private double reward; 

        // List of transactions in this block.
        private List<Transaction> transactionList;

        //
        private long blockTime;

        public long getBlockTime()
        {
            return blockTime;
        }

        public int getDifficulty()
        {
            return difficulty;
        }

        public int getIndex()
        {
            return index;
        }

        public String getHash()
        {
            return hash;
        }

        public String getPreviousHash()
        {
            return previousHash;
        }

        public List<Transaction> getTransactionList()
        {
            return transactionList;
        }

        public String getMerkleRoot()
        {
            return merkleRoot;
        }

        /// <summary>
        /// Determines whether or not threading is to be used. 
        /// </summary>
        public void mineHash()
        {
            // Stop watch used generate block time.
            var stopWatch = new System.Diagnostics.Stopwatch();

            // Starts the stop watch.
            stopWatch.Start();

            // If threading is false...
            if (BlockchainApp.getThreading() == false)
            {
                // Call normal threading method.
                hash = Mine();
            }

            // Otherwise...
            else
            {
                // Apply threaded mining method.
                hash = ThreadedMine();
            }

            // Stop the stop watch.
            stopWatch.Stop();

            // Set block time equal to the time elapsed from the stop watch.
            blockTime = stopWatch.ElapsedMilliseconds;

            Console.WriteLine("Difficulty: " + difficulty + " " + "Time: " + blockTime);
        }

        /// <summary>
        /// Create a Hash which satisfies the difficulty level required for PoW
        /// </summary>
        /// <returns>Hash of the block.</returns>
        public String Mine()
        {
            // Initalise the nonce
            nonce = 0;

            // Hash the block
            String tempHash = CreateHash();

            // A string for analysing the PoW requirement
            String re = new string('0', difficulty);

            // Check the resultant hash against the "re" string
            while (!tempHash.StartsWith(re))
            {
                // Increment the nonce should the difficulty level not be satisfied
                nonce++;

                // Rehash with the new nonce as to generate a different hash
                tempHash = CreateHash();
            }

            return tempHash; // Return the hash meeting the difficulty requirement
        }

        /// <summary>
        /// Initial mine method when threading is enabled.
        /// </summary>
        /// <returns>Hash of the block.</returns>
        public string ThreadedMine()
        {
            // Initialises the value of the first e-nonce to 0.
            eNonceEven = 0;

            // Initialises the value of the second e-nonce to 1.
            eNonceOdd = 1;

            // First additional thread for mining.
            Thread evenMineThread = new Thread(EvenMine);

            // Second addtional thread for mining.
            Thread oddMineThread = new Thread(OddMine);

            // Start thread for generating hashes with e-nonce with numbers that are even.
            evenMineThread.Start();

            // Start thread for generating hashes with e-nonce with numbers that are odd.
            oddMineThread.Start();
            
            // While both threads are running...
            while (evenMineThread.IsAlive == true || oddMineThread.IsAlive == true)
            { 
                // Sleep the main thread.
                Thread.Sleep(1);
            }
            
            // If the even hash solved the puzzle...
            if (hashEven.StartsWith(new string('0', difficulty)))
            {
                // Set the value of the nonce to the even valued e-nonce.
                nonce = eNonceEven;

                // Return the value of the (even) hash.
                return hashEven;
            }

            // Otherwise...
            else
            {
                // Set the value of the nonce to the odd valued e-nonce.
                nonce = eNonceOdd;

                // Return the value of the (odd) hash.
                return hashOdd;
            }
        }

        /// <summary>
        /// Mining method that uses the nonce with even values. 
        /// </summary>
        public void EvenMine()
        {
            // Number of 0s the hash should start with.
            string re = new string('0', difficulty);

            // While the hash does not begin with 0.
            while (!hashEven.StartsWith(re))
            {
                // Increment the nonce by 2.
                eNonceEven += 2;

                // Create hash.
                hashEven = ThreadedCreateHash(eNonceEven);
                
                // If the other thread has solved the puzzle...
                if (hashOdd.StartsWith(re) == true)
                {
                    // Sleep thread.
                    Thread.Sleep(1);

                    // Exit loop.
                    break;
                }
            }
        }

        /// <summary>
        /// Mining method that uses the nonce with odd values. 
        /// </summary>
        public void OddMine()
        {
            // Number of 0s the hash should start with.
            string re = new string('0', difficulty);

            // While the hash does not begin with 0.
            while (!hashOdd.StartsWith(re))
            {
                // Increment the nonce by 2.
                eNonceOdd += 2;

                // Create hash.
                hashOdd = ThreadedCreateHash(eNonceOdd);

                // If the other thread has solved the puzzle...
                if (hashEven.StartsWith(re) == true)
                {
                    // Sleep thread.
                    Thread.Sleep(1);

                    // Exit loop.
                    break;
                }
            }
        }

        /// <summary>
        /// Creates a hash of the block using its properties as inputs.
        /// </summary>
        /// <returns>Hash of block.</returns>
        public String CreateHash()
        {
            // Stores hash of block.
            String tempHash = String.Empty;

            // SHA256 object that is used to create a hash.
            SHA256 hasher = SHA256Managed.Create();

            // Concatenate all of the blocks properties including nonce as to generate a new hash on each call.
            String input = timestamp.ToString() + index + previousHash + nonce + merkleRoot;

            // Apply the hash function to the block as represented by the string "input".
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            /* Reformat to a string */
            foreach (byte x in hashByte)
            {
                tempHash += String.Format("{0:x2}", x);
            }

            // Return hash.
            return tempHash;
        }

        /// <summary>
        /// Creates a hash of the block using its properties as inputs.
        /// </summary>
        /// <param name="enonce">extra nonce.</param>
        /// <returns>hash of block.</returns>
        public String ThreadedCreateHash(long enonce)
        {
            // Stores hash of block.
            String tempHash = String.Empty;

            SHA256 hasher = SHA256Managed.Create();

            // Concatenate all of the blocks properties including nonce as to generate a new hash on each call.
            String input = timestamp.ToString() + index + previousHash + enonce + merkleRoot;
            
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));

            foreach (byte x in hashByte)
            {
                tempHash += String.Format("{0:x2}", x);
            }

            return tempHash;
        }

        // Create reward for incentivising the mining of block
        public Transaction createRewardTransaction(List<Transaction> transactions)
        {
            // Sum all transaction fees
            double fees = transactions.Aggregate(0.0, (acc, t) => acc + t.fee);

            // Issue reward as a transaction in the new block
            return new Transaction("Mine Rewards", "", minerAddress, (reward + fees), 0);
        }

        // Merkle Root Algorithm - Encodes transactions within a block into a single hash
        public static String MerkleRoot(List<Transaction> transactionList)
        {
            List<String> hashes = transactionList.Select(t => t.hash).ToList(); // Get a list of transaction hashes for "combining"

            // Handle Blocks with... // No transactions
            if (hashes.Count == 0) 
            {
                return String.Empty;
            }

            // One transaction - hash with "self"
            if (hashes.Count == 1) 
            {
                return HashCode.HashTools.combineHash(hashes[0], hashes[0]);
            }
            while (hashes.Count != 1) // Multiple transactions - Repeat until tree has been traversed
            {
                List<String> merkleLeaves = new List<String>(); // Keep track of current "level" of the tree

                for (int i = 0; i < hashes.Count; i += 2) // Step over neighbouring pair combining each
                {
                    if (i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i])); // Handle an odd number of leaves
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i + 1])); // Hash neighbours leaves
                    }
                }
                hashes = merkleLeaves; // Update the working "layer"
            }
            return hashes[0]; // Return the root node
        }

        public override string ToString()
        {
            return "[BLOCK START]"
                + "\nIndex: " + index
                + "\nTimestamp: " + timestamp
                + "\nPrevious Hash: " + previousHash
                + "\n-- PoW --"
                + "\nDifficulty Level: " + difficulty
                + "\nNonce: " + nonce
                + "\nHash: " + hash
                + "\n-- Rewards --"
                + "\nReward: " + reward
                + "\nMiners Address: " + minerAddress
                + "\n-- " + transactionList.Count + " Transactions --"
                + "\nMerkle Root: " + merkleRoot
                + "\n" + String.Join("\n", transactionList)
                + "\n[BLOCK END]";
        }
    }
}
