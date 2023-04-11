using ChatApp.GlobalConstants;
using ChatApp.Models;
using ChatApp.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Network
{
    public class HubConnectionManagerMainPage : HubConnectionManager
    {
        //Precondition: ConnectToHub() has been called
        public void SetUpHubConnectionListenersMainPage(string yourPhoneNumber, ContactsPage contactsPage)
        {
            bool isPhoneNumberNull = yourPhoneNumber.Equals(ApplicationConstants.NO_PHONE_NUMBER);
            Debug.Assert(!isPhoneNumberNull, "SetUpHubConnectionListenersMainPage function received a null phone number");

            SetUpHubConnectionHandlerToRecieveNewMessageCounts(yourPhoneNumber, contactsPage);
            SetHubConnectionhandlerToRecieveNewMsg(yourPhoneNumber, contactsPage);
        }

        private void SetHubConnectionhandlerToRecieveNewMsg(string yourPhoneNumber, ContactsPage contactsPage)
        {
            hubConnection.On<ChatMessage>(yourPhoneNumber, (chatMessage) =>
            {
                contactsPage.IncreaseNewMsgCountOfFriendByOneInUI(chatMessage.PhoneNumOfWriter);
            });
        }

        private void SetUpHubConnectionHandlerToRecieveNewMessageCounts(string yourPhoneNumber, ContactsPage contactsPage)
        {
            hubConnection.On<Dictionary<string, int>>(yourPhoneNumber + "-get_new_messages_count_for_friends", async (listOfNewMsgCountsForFriends) =>
            {
                await UpdateUIWithNewMsgCountForFriendsThatLeftMessages(listOfNewMsgCountsForFriends, contactsPage);
            });
        }

        private async Task UpdateUIWithNewMsgCountForFriendsThatLeftMessages(Dictionary<string, int> listOfNewMsgCountsForFriends, ContactsPage contactsPage)
        {
            //FIRST SET NEW MSG COUNT FOR ALL FRIENDS TO ZERO IN THE UI
            await contactsPage.SetNewMsgCountZeroAllFriends();
            
            //FOR EACH FRIEND UPDATE THE NEW MSG COUNT IN THE UI
            ObservableCollection<Friend> observableCollectionFriends = contactsPage.GetFriendList();
            foreach (KeyValuePair<string, int> friendWithNewMsgCount in listOfNewMsgCountsForFriends)
            {
                for (int i = 0; i < observableCollectionFriends.Count; i++)
                {
                    string friendWithNewMsgCountPhoneNum = friendWithNewMsgCount.Key;
                    if ((observableCollectionFriends[i].ID).Equals(friendWithNewMsgCountPhoneNum))
                    {
                        //UPDATE THE NEW MESSAGE COUNT FOR THE MATCHING FRIEND IN THE OBSERVABLE COLLECTION SO THAT IT DISPLAYS IN THE UI

                        //make copy of friend about to be removed then change the count
                        Friend updatedFriend = new Friend(); 
                        updatedFriend.CanChatWith = observableCollectionFriends[i].CanChatWith;
                        updatedFriend.FriendName = observableCollectionFriends[i].FriendName;
                        updatedFriend.ID = observableCollectionFriends[i].ID;
                        updatedFriend.NewMsgCount = friendWithNewMsgCount.Value;

                        //Update the obserableCollection by replacing the old friend with the newly created friend with updated new msg count
                        observableCollectionFriends.RemoveAt(i);
                        observableCollectionFriends.Insert(i, updatedFriend);
                    }
                }
            }
        }
    }
}
