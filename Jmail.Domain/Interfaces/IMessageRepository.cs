﻿using Jmail.Domain.Entities;

namespace Jmail.Domain.Interfaces;

public interface IMessageRepository
{
    Task SendMessage(Message message);
}