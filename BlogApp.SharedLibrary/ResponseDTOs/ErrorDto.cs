using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApp.SharedLibrary.ResponseDTOs
{
    public class ErrorDto
    {
        public List<string> Errors { get; private set; }
        public bool IsShow { get; private set; }


        public ErrorDto()
        {
            this.Errors = new List<string>();
        }
        public ErrorDto(string error)
        {
            this.Errors.Add(error);
            this.IsShow = true;
        }

        public ErrorDto(List<string> errors, bool ısShow)
        {
            Errors = errors;
            IsShow = ısShow;
        }
    }
}
