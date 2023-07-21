using Application.Interface;
using Application.InterfaceRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MessageService : IMessageService
    
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateMessageAsync(Guid groupID, string content)
        {
            Message newMess = new Message
            {
                Content = content,
                GroupId = groupID,

            };
            
            await _messageRepository.AddAsync(newMess);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
