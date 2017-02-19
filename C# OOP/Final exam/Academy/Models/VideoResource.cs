using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Utils
{
    public class VideoResource : Resource
    {
        private readonly DateTime uploadedOn;
        public VideoResource(DateTime uploadedOn, string name, string url) : base(name, url)
        {
            this.uploadedOn = uploadedOn;
            this.type = ResourceType.Video;
        }

        public DateTime UploadedOn
        {
            get
            {
                return this.uploadedOn;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendLine($@"     - Uploaded on: {this.UploadedOn.ToString("yyyy-MM-dd hh:mm:ss tt")}");
            return result.ToString();
        }
    }
}
