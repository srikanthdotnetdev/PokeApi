namespace PokeApi.GraphQL;

 
    public static class CustomLoggerFactory
    {
        public static ILoggerFactory LogFactory
        {
            get
            {
                using ILoggerFactory loggerFactory =
                    Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
                        builder.AddSystemdConsole(options =>
                        {
                            options.IncludeScopes = true;
                            options.TimestampFormat = "hh:mm:ss ";
                        }));
                return loggerFactory;
            }
        }
    }
 