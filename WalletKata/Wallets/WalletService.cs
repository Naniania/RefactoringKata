using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        public List<Wallet> GetWalletsByUser(User user)
        {
            List<Wallet> walletList;
            User loggedUser = UserSession.GetInstance().GetLoggedUser();
            bool isFriend = false;

            if (loggedUser)
            {
                walletList = (user.GetFriends().IndexOf(loggedUser) != -1) ? WalletDAO.FindWalletsByUser(user) : new List<Wallet>();
                return walletList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }      
        }         
    }
}