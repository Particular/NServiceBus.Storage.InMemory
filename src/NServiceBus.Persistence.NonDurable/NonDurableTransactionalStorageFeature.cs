﻿namespace NServiceBus
{
    using Features;
    using Microsoft.Extensions.DependencyInjection;

    class NonDurableTransactionalStorageFeature : Feature
    {
        /// <summary>
        /// Called when the features is activated.
        /// </summary>
        protected override void Setup(FeatureConfigurationContext context)
        {
            context.Services.AddSingleton<NonDurableSynchronizedStorage>();
            context.Services.AddSingleton<NonDurableTransactionalSynchronizedStorageAdapter>();
        }
    }
}