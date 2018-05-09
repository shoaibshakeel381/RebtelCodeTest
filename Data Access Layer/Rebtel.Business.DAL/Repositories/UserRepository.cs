﻿using System;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {
            
        }

        public override void Create(UserEntity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            base.Create(entity);
        }

        public void AddUserSubscription(UserEntity user, SubscriptionEntity subscription)
        {
            user.UserSubscriptions.Add(new UserSubscriptionEntity
            {
                UserId = user.Id,
                User = user,
                SubscriptionId = subscription.Id,
                Subscription = subscription
            });

            Update(user);
        }
    }
}
