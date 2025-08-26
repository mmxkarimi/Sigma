using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.App.Extensions.Models
{
    public class ChatHistory
    {
        public string Title { get; set; }
        public DateTime LastUsed { get; set; }
        public List<Chat> History { get; set; }
    }
}
