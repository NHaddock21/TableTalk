using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ChatApp.Models;

namespace ChatApp.Models
{
    class ThreadParticipant
    {
        [PrimaryKey, AutoIncrement]
        public int Message_Thread_id { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }

    }
    
}