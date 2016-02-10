﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Creationdate { get; set; }

        public int ArticleId { get; set; }

        public int ProfileId { get; set; }
    }
}
