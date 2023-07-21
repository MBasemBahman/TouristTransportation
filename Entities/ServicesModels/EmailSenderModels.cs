﻿using MimeKit;

namespace Entities.ServicesModels
{
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class EmailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<string> OtherContent { get; set; }

        public string HtmlContent { get; set; }

        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
        }

        public EmailMessage(IEnumerable<string> to, string subject, string content, List<string> otherContent, string rootPath, string templatePath) : this(to, subject, content, rootPath, templatePath)
        {
            OtherContent = otherContent;
        }

        public EmailMessage(IEnumerable<string> to, string subject, string content, string rootPath, string templatePath) : this(to, subject, content)
        {
            string pathToFile = rootPath
                          + Path.DirectorySeparatorChar.ToString()
                          + templatePath;

            BodyBuilder builder = new();
            using (StreamReader SourceReader = File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            HtmlContent = builder.HtmlBody;
        }
    }
}
