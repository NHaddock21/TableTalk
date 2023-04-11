using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.GlobalConstants
{
    static class ApplicationConstants
    {
        
        public const String ChutHubUrl = "https://chathubapp220230405221620.azurewebsites.net/";

        //DATABASE RELATED
        public const string MSG_ID = "MsgID";
        public const string MSG_PHONE_NUM_WRITER = "PhoneNumOfWriter";
        public const string MSG_COLUMN = "Msg";
        public const string DATE_COLUMN = "Date";
        public const string WRITER_COLUMN = "Writer";
        public const string SEEN_COLUMN = "SeenByRecipient";

        //UI Related
        public const int NUM_DIGITS_PHONE_NUM = 10;
        public const string PHONE_PROMPT_DESC = "Enter your 10 digit phone number including area code (numbers only). Leave out the country code";
        public const string PHONE_PROMPT_ERR_DESC = "Phone number NOT IN CORRECT FORMAT. Enter your 10 digit phone number(numbers only), including area code, but not including the country code";

        //PREFERENCE NAMES
        public const string FIRST_TIME_START_APP_PREF = "first_time_start_app";
        public const string YOUR_PHONE_NUM_PREF = "your_phone_number";
        public const string JUST_ENTERED_PHONENUM_PREF = "just_entered_phone_num";

        //DEFAULT PREF VALUES
        public const string NO_PHONE_NUMBER = "no_phone_number";
    }
}
