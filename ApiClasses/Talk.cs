using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegaplanAPILibrary.ApiClasses
{
    public class Talk
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Folder { get; set; }
        public DateTime TimeCreated { get; set; }
        public Recipient[] To { get; set; }
        public class Recipient
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
