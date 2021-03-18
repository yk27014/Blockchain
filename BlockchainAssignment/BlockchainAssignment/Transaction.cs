using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Transaction
    {
        /// <summary>
        /// Constructor for the transaction 
        /// </summary>
        /// <param name="publicKey">Sender address</param>
        /// <param name="privateKey">sender's private key</param>
        /// <param name="recieverKey">Reciever address</param>
        /// <param name="amount">Amount transfered</param>
        /// <param name="fee">Cost of transfer</param>
        public Transaction(String publicKey, String privateKey, String recieverKey, double amount, double fee)
        {
            timestamp = DateTime.Now;

            senderAddress = publicKey;
            recipientAddress = recieverKey;

            this.amount = amount;
            this.fee = fee;

            // Hash the transaction attributes
            hash = CreateHash();

            // Sign the hash with the senders private key ensuring validity
            signature = Wallet.Wallet.CreateSignature(publicKey, privateKey, hash);
        }

        // Time of creation
        private DateTime timestamp;

        // Sender's public key addresses
        private String senderAddress;

        // Reciever's public key addresses
        public String recipientAddress;

        // Quantity transfered.
        public double amount;

        // Cost of transfer.
        public double fee;

        // Hash value ID for the transaction.
        public String hash;

        // Transaction signature.
        public String signature;

        public DateTime getTimestamp()
        {
            return timestamp;
        }

        public String getSenderAddress()
        {
            return senderAddress;
        }

        /* Hash the transaction attributes using SHA256 */
        public String CreateHash()
        {
            String hash = String.Empty;
            SHA256 hasher = SHA256Managed.Create();

            // Concatenate all transaction properties 
            String input = timestamp + senderAddress + recipientAddress + amount + fee;

            // Apply the hash function to the "input" string 
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Reformat to a string
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);

            return hash;
        }

        // Represent a transaction as a string for output to UI.
        public override string ToString()
        {
            return "   [TRANSACTION START]"
                + "\n  Timestamp: " + timestamp
                + "\n  -- Verification --"
                + "\n  Hash: " + hash
                + "\n  Signature: " + signature
                + "\n  -- Quantities --"
                + "\n  Transferred: " + amount + " Rubyte"
                + "\n  Fee: " + fee
                + "\n  -- Participants --"
                + "\n  Sender: " + senderAddress
                + "\n  Reciever: " + recipientAddress
                + "\n  [TRANSACTION END]";
        }
    }
}
