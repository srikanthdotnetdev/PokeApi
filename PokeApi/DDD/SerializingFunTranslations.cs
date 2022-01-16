﻿ 

namespace PokeApi.DDD
{
    
    public class Success
    {
        public int total { get; set; }
    }

    public class Contents
    {
        public string translated { get; set; }
        public string text { get; set; }
        public string translation { get; set; }
    }

    public class SerializedMessage
    {
        public Success success { get; set; }
        public Contents contents { get; set; }
    }

}
