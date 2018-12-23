namespace MognetPlugin.Model
{
    internal class DiscordChannel
    {
        public string guild { get; set; }
        public string channel { get; set; }

        public DiscordChannel()
        {
            this.guild = "";
            this.channel = "";
        }

        public DiscordChannel(string guild, string channel)
        {
            this.guild = guild;
            this.channel = channel;
        }
    }
}