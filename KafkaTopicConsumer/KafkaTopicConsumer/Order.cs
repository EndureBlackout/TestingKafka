﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTopicConsumer
{
    public class Order
    {
        public string Id { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}
