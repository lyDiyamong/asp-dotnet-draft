using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Comment
{
    public class UpdateCommentReqDto
    {
        
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}