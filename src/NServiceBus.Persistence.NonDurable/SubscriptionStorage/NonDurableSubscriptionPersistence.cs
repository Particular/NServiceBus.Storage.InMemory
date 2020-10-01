﻿namespace NServiceBus.Features
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Used to configure non durable subscription persistence.
    /// </summary>
    public class NonDurableSubscriptionPersistence : Feature
    {
        internal NonDurableSubscriptionPersistence()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            DependsOn<MessageDrivenSubscriptions>();
#pragma warning restore CS0618 // Type or member is obsolete
        }

        /// <summary>
        /// See <see cref="Feature.Setup" />.
        /// </summary>
        protected override void Setup(FeatureConfigurationContext context)
        {
            context.Services.AddSingleton(new NonDurableSubscriptionStorage());
        }
    }
}