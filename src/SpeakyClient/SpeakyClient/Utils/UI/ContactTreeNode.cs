using System;
using System.Collections.Generic;
using SpeakyClient.Speaky.Api.Json.Classes;

namespace SpeakyClient.Utils.UI
{
    public class ContactTreeNode : Gtk.TreeNode
    {
        [Gtk.TreeNodeValue(Column = 0)]
        public string Firstname => User.firstname;

        [Gtk.TreeNodeValue(Column = 1)]
        public string Lastname => User.lastname;

        [Gtk.TreeNodeValue(Column = 2)]
        public string Country => User.country;
        
        public User User { get; }

        public ContactTreeNode(User user)
        {
            User = user;
        }
    }
}
