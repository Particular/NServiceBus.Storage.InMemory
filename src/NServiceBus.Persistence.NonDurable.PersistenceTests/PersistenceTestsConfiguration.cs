﻿namespace NServiceBus.PersistenceTesting
{
    using System.Threading;
    using System.Threading.Tasks;
    using NServiceBus;
    using NServiceBus.Outbox;
    using NServiceBus.Sagas;
    using Persistence;

    public partial class PersistenceTestsConfiguration
    {
        public bool SupportsDtc => true;

        public bool SupportsOutbox => true;

        public bool SupportsFinders => false;

        public bool SupportsPessimisticConcurrency => false;

        public ISagaIdGenerator SagaIdGenerator { get; private set; }

        public ISagaPersister SagaStorage { get; private set; }

        public ISynchronizedStorage SynchronizedStorage { get; private set; }

        public ISynchronizedStorageAdapter SynchronizedStorageAdapter { get; private set; }

        public IOutboxStorage OutboxStorage { get; private set; }

        public Task Configure(CancellationToken cancellationToken = default)
        {
            SagaIdGenerator = new DefaultSagaIdGenerator();
            SagaStorage = new NonDurableSagaPersister();
            SynchronizedStorage = new NonDurableSynchronizedStorage();
            SynchronizedStorageAdapter = new NonDurableTransactionalSynchronizedStorageAdapter();
            OutboxStorage = new NonDurableOutboxStorage();

            return Task.CompletedTask;
        }

        public Task Cleanup(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}