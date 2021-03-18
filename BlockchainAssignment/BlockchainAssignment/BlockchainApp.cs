using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        /// <summary>
        /// Default Constructor for the Blockchain Application.
        /// </summary>
        public BlockchainApp()
        {
            // Initialise UI Components.
            InitializeComponent();

            // Initialise a new blockchain.
            blockchain = new Blockchain();

            // Update UI with an initalisation message.
            outputRichTxtBox.Text = "New Blockchain Initialised!";

            defaultRadioBtn.Checked = true;

            onRadioBtn.Checked = true;

            threading = onRadioBtn.Checked;

            dynamicRadioBtn.Checked = true;

            dynamicDifficulty = dynamicRadioBtn.Checked;
        }

        // Global blockchain object.
        private Blockchain blockchain;

        private int miningSettingID;

        private static bool threading;

        private static bool dynamicDifficulty;

        public static bool getThreading()
        {
            return threading;
        }

        public static bool getDynamicDifficulty()
        {
            return dynamicDifficulty;
        }

        /// <summary>
        /// Prints the Nth block in the chain, where N is a user inputted number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printBlockBtn_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(blockNumTxtBox.Text, out int index))
            {
                outputRichTxtBox.Text = blockchain.GetBlockAsString(index);
            }

            else
            {
                outputRichTxtBox.Text = "Invalid Block No.";
            }
        }

        /// <summary>
        /// Creates a new wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genNewWalletBtn_Click(object sender, EventArgs e)
        {
            // Create new wallet.
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out String privKey);
            
            // Set
            publicKeyTxtBox.Text = myNewWallet.publicID;
            privateKeyTxtBox.Text = privKey;
        }

        /// <summary>
        /// Value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateKeysBtn_Click(object sender, EventArgs e)
        {
            if (Wallet.Wallet.ValidatePrivateKey(privateKeyTxtBox.Text, publicKeyTxtBox.Text))
            {
                outputRichTxtBox.Text = "Keys are valid";
            }

            else
            {
                outputRichTxtBox.Text = "Keys are invalid";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTransactionBtn_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(publicKeyTxtBox.Text, privateKeyTxtBox.Text, recieverKeyTxtBox.Text, Double.Parse(amountTxtBox.Text), Double.Parse(feeTxtBox.Text));
            blockchain.getTransactionPool().Add(transaction);
            outputRichTxtBox.Text = transaction.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genNewBlockBtn_Click(object sender, EventArgs e)
        {
            // Retrieve pending transactions to be added to the newly generated Block
            List<Transaction> transactions = blockchain.GetPendingTransactions(miningSettingID, publicKeyTxtBox.Text);

            // Create and append the new block - requires a reference to the previous block, a set of transactions and the miners public address (For the reward to be issued)
            Block newBlock = new Block(blockchain.GetLastBlock(), transactions, publicKeyTxtBox.Text);
            blockchain.getBlocks().Add(newBlock);
            outputRichTxtBox.Text = blockchain.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printChainBtn_Click(object sender, EventArgs e)
        {
            outputRichTxtBox.Text = blockchain.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readPendingTransactionsBtn_Click(object sender, EventArgs e)
        {
            String pendingTransactions = String.Join("\n", blockchain.getTransactionPool());
            
            if (pendingTransactions != String.Empty)
            {
                outputRichTxtBox.Text = pendingTransactions;
            }

            else
            {
                outputRichTxtBox.Text = "No Transactions Are Pending.";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullChainValidationBtn_Click(object sender, EventArgs e)
        {
            // CASE: Genesis Block - Check only hash as no transactions are currently present
            if (blockchain.getBlocks().Count == 1)
            {
                // Recompute Hash to check validity
                if (!Blockchain.ValidateHash(blockchain.getBlocks()[0]))
                {
                    outputRichTxtBox.Text = "Blockchain is invalid";
                }

                else
                {
                    outputRichTxtBox.Text = "Blockchain is valid";
                }

                return;
            }

            for (int i = 1; i < blockchain.getBlocks().Count - 1; i++)
            {
                // Check hash "chain"
                // Check each blocks hash
                // Check transaction integrity using Merkle Root 
                if (blockchain.getBlocks()[i].getPreviousHash() != blockchain.getBlocks()[i - 1].getHash() || !Blockchain.ValidateHash(blockchain.getBlocks()[i]) || !Blockchain.ValidateMerkleRoot(blockchain.getBlocks()[i])                                                      )
                {
                    outputRichTxtBox.Text = "Blockchain is invalid";
                    return;
                }
            }

            // 
            outputRichTxtBox.Text = "Blockchain is valid";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBalenceBtn_Click(object sender, EventArgs e)
        {
            outputRichTxtBox.Text = blockchain.GetBalance(publicKeyTxtBox.Text).ToString() + " Rubyte Coin";
        }

        private void MiningSettingRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (greedyRadioBtn.Checked == true)
            {
                miningSettingID = 1;
            }

            else if (unpredictableRadioBtn.Checked == true)
            {
                miningSettingID = 2;
            }

            else if (altruisticRadioBtn.Checked == true)
            {
                miningSettingID = 3;
            }

            else if (addressRadioBtn.Checked == true)
            {
                miningSettingID = 4;
            }

            else
            {
                miningSettingID = 0;
            }
        }

        private void ThreadingRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            threading = onRadioBtn.Checked;
        }

        private void difficultyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dynamicDifficulty = dynamicRadioBtn.Checked;
        }
    }
}
