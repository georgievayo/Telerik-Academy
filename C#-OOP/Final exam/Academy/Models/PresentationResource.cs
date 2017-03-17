using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class PresentationResource : Resource, ILectureResouce
    {
        public PresentationResource(string name, string url) : base(name, url)
        {
            this.type = ResourceType.Presentation;
        }
    }
}
