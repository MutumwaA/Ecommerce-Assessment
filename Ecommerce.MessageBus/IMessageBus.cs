﻿using System;
using System.Threading.Tasks;

namespace Ecommerce.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}