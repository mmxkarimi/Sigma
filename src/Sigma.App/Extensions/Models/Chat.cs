using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.App.Extensions.Models
{
    public class Chat
    {
        public ChatRole Role { get; set; }
        
        public string Prompt { get; set; }
    }
    public enum ChatRole
    {
        System ,
        Assistant ,
        User
    }
}
