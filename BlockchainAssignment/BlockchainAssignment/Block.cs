
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
            
            // 
            mineHash();

            Blockchain.incrementTotalBlockTime(blockTime);
        }

        public Block(Block lastBlock, List<Transaction> transactions, String minerAddress)
        {
            // 
            timestamp = DateTime.Now;
            index = lastBlock.getIndex() + 1;
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


            if (BlockchainApp.getDynamicDifficulty() == true)
            {
                // If the difficulty 
                if (lastBlock.getBlockTime() < (Blockchain.getTotalBlockTime() / (lastBlock.getIndex() + 1)) * 0.125)
                {
                    difficulty = 5;
                }

                // 
                else if (lastBlock.getBlockTime() > (Blockchain.getTotalBlockTime() / (lastBlock.getIndex() + 1)) * 1.25)
                {
                    difficulty = 3;

                }

                else
                {
                    difficulty = 4;
                }
            }

            //
            mineHash();

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

        private long nonce;

        private long eNonceEven;

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

        public void mineHash()
        {
            var stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();

            if (BlockchainApp.getThreading() == false)
            {
                hash = Mine();
            }

            else
            {
                hash = ThreadedMine();
            }

            stopWatch.Stop();

            blockTime = stopWatch.ElapsedMilliseconds;

            Console.WriteLine("Difficulty: " + difficulty + " " + "Time: " + blockTime);
        }

        // Create a Hash which satisfies the difficulty level required for PoW
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

        public string ThreadedMine()
        {
            eNonceEven = 0;
            eNonceOdd = 1;

            Thread evenMineThread = new Thread(EvenMine);
            Thread oddMineThread = new Thread(OddMine);

            evenMineThread.Start();
            oddMineThread.Start();
            
            while (evenMineThread.IsAlive == true || oddMineThread.IsAlive == true)
            { 
                Thread.Sleep(1);
            }
            
            if (hashEven.StartsWith(new string('0', difficulty)))
            {
                nonce = eNonceEven;
                return hashEven;
            }

            else
            {
                nonce = eNonceOdd;
                return hashOdd;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void EvenMine()
        {
            string re = new string('0', difficulty);

            while (!hashEven.StartsWith(re))
            {
                eNonceEven += 2;

                hashEven = ThreadedCreateHash(eNonceEven);
                
                if (hashOdd.StartsWith(re) == true)
                {
                    Thread.Sleep(1);
                    return;
                }
            }
        }

        /// <summary>
        /// Mining method that uses the nonce with odd values. 
        /// </summary>
        public void OddMine()
        {
            string re = new string('0', difficulty);

            while (!hashOdd.StartsWith(re))
            {
                eNonceOdd += 2;

                hashOdd = ThreadedCreateHash(eNonceOdd);

                if (hashEven.StartsWith(re) == true)
                {
                    Thread.Sleep(1);
                    return;
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
        /// <param name="enonce"></param>
        /// <returns></returns>
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
