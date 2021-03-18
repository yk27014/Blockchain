using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        /// <summary>
        /// Default constructor for the Blockchain class.
        /// </summary>
        public Blockchain()
        {
            /*
             * Initialise list of blocks.
             * Create and add genesis block to list.
             */
            blocks = new List<Block>() { new Block() };
        }

        // List of block objects forming the blockchain
        private List<Block> blocks;

        // Maximum number of transactions per block.
        private int transactionsPerBlock = 5;

        // List of pending transactions to be mined
        private List<Transaction> transactionPool = new List<Transaction>();

        private static long totalBlockTime;

        public static void incrementTotalBlockTime(long time)
        {
            totalBlockTime += time;
        }

        public static long getTotalBlockTime()
        {
            return totalBlockTime;
        }

        public List<Transaction> getTransactionPool()
        {
            return transactionPool;
        }

        public List<Block> getBlocks()
        {
            return blocks;
        }

        // Retrieves the most recently appended block in the blockchain
        public Block GetLastBlock()
        {
            return blocks[blocks.Count - 1];
        }

        /// <summary>
        /// Retrieve pending transactions and remove from pool.
        /// </summary>
        /// <param name="miningSettingID">Numerical value corresponding to currently selected mining setting.</param>
        /// <param name="minerAddress">Miner Address's.</param>
        /// <returns></returns>
        public List<Transaction> GetPendingTransactions(int miningSettingID, String minerAddress)
        {
            // Number of transactions to retrieve dependent on the number of pending transactions and the limit specified
            int numOfTransactions = Math.Min(transactionsPerBlock, transactionPool.Count);

            // "Pull" transactions from the transaction list (modifying the original list)
            List<Transaction> transactions = new List<Transaction>();

            // Switch statement to decide which mining setting is to be used.
            switch (miningSettingID)
            {
                // Greedy 
                case 1:
                    // Sorts the list in order of fee size.
                    transactionPool.Sort((x, y) => x.fee.CompareTo(y.fee));

                    // Reverse's the order so the largest fee's are first.
                    transactionPool.Reverse();

                    // "Pull" transactions from the transaction list (modifying the original list)
                    transactions = transactionPool.GetRange(0, numOfTransactions);

                    // Removes selected transactions from the transactions. 
                    transactionPool.RemoveRange(0, numOfTransactions);

                    // break statement.
                    break;

                // Unpredictable
                case 2:
                    // New instance of a random object.
                    Random random = new Random();

                    // While the number of transactions is less than the number of transactions to be made.
                    while (transactions.Count() < numOfTransactions)
                    {
                        // Select random transaction from the transaction pool.
                        Transaction transaction = transactionPool[random.Next(0, transactionPool.Count())];
                        
                        // Add transaction to transactions.
                        transactions.Add(transaction);
                        
                        // Remove transaction from transaction pool.
                        transactionPool.Remove(transaction);
                    }

                    // Break statement.
                    break;

                // Altruistic
                case 3:
                    // Sorts the transaction pool by date.
                    transactionPool.Sort((transaction1, transaction2) => DateTime.Compare(transaction1.getTimestamp(), transaction2.getTimestamp()));

                    // "Pull" transactions from the transaction list (modifying the original list)
                    transactions = transactionPool.GetRange(0, numOfTransactions);

                    // 
                    transactionPool.RemoveRange(0, numOfTransactions);
                    break;

                // Address Based
                case 4:
                    // For each transaction in the transaction pool.
                    foreach (Transaction transaction in transactionPool)
                    {
                        // If the number of transactions is less than what is required.
                        if (transactions.Count() < numOfTransactions)
                        {
                            // Check if miner's address is equal to the sender's address of the transaction.
                            if (minerAddress == transaction.getSenderAddress())
                            {
                                // Add transaction to transactions.
                                transactions.Add(transaction);
                            }
                        }

                        // If number of transactions has been met.
                        else
                        {
                            // Break.
                            break;
                        }
                    }

                    
                    foreach (Transaction transaction in transactionPool)
                    {
                        if (transactions.Count() < numOfTransactions)
                        {
                            if (transactions.Contains(transaction) == false)
                            {
                                transactions.Add(transaction);
                            }
                        }

                        else
                        {
                            break;
                        }
                    }
                    
                    foreach (Transaction transaction in transactions)
                    {
                        transactionPool.Remove(transaction);
                    }

                    break;

                // Default
                default:
                    // "Pull" transactions from the transaction list (modifying the original list)
                    transactions = transactionPool.GetRange(0, numOfTransactions);

                    // 
                    transactionPool.RemoveRange(0, numOfTransactions);
                    break;
            }

            // Return the extracted transactions
            return transactions;
        }

        // Prints the block at the specified index to the UI
        public String GetBlockAsString(int index)
        {
            // Check if referenced block exists
            if (index >= 0 && index < blocks.Count)
            {
                // Return block as a string
                return blocks[index].ToString();
            }

            else
            {
                return "No such block exists!";
            }
        }

        // Check the balance associated with a wallet based on the public key
        public double GetBalance(String address)
        {
            // Accumulator value
            double balance = 0;

            // Loop through all approved transactions in order to assess account balance
            foreach (Block block in blocks)
            {
                foreach (Transaction transaction in block.getTransactionList())
                {
                    if (transaction.recipientAddress.Equals(address))
                    {
                        balance += transaction.amount; // Credit funds recieved
                    }

                    if (transaction.getSenderAddress().Equals(address))
                    {
                        balance -= (transaction.amount + transaction.fee); // Debit payments placed
                    }
                }
            }
            return balance;
        }

        // Check validity of a blocks hash by recomputing the hash and comparing with the mined value
        public static bool ValidateHash(Block block)
        {
            String rehash = block.CreateHash();
            return rehash.Equals(block.getHash());
        }

        // Check validity of the merkle root by recalculating the root and comparing with the mined value
        public static bool ValidateMerkleRoot(Block block)
        {
            String reMerkle = Block.MerkleRoot(block.getTransactionList());
            return reMerkle.Equals(block.getMerkleRoot());
        }

        // Output all blocks of the blockchain as a string
        public override string ToString()
        {
            return String.Join("\n \n", blocks);
        }
    }
}
