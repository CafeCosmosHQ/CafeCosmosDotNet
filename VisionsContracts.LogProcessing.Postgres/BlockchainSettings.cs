namespace VisionsContracts.LogProcessing.Postgres
{
    public class BlockchainSettings
    {
        public string RpcUrl { get; set; }
        public string Address { get; set; }
        public long StartAtBlockNumberIfNotProcessed { get; set; } = 0;
        public int NumberOfBlocksToProcessPerRequest { get; set; } = 1000;

    }
}

