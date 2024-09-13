
<h1 id="title">.NET Email Sending </h1>

<p id="description">A .NET example for sending emails using MailKit and MimeKit. This project demonstrates how to:</p>
<ul>
  <li>Send basic email messages</li>
  <li>Attach files</li>
  <li>Send HTML content</li>
</ul>

<h2>🧐 Features</h2>
<p>Here're some of the project's best features:</p>
<ul>
  <li>Easy-to-follow examples</li>
  <li>Asynchronous email sending</li>
</ul>

<h2>🛠️ Installation Steps:</h2>

<p>1. Clone the Repository</p>
<pre><code>git clone https://github.com/ziadhanii/sending-emails-with-mailkit-and-mimekit.git</code></pre>

<p>2. Install Dependencies</p>
<pre><code>dotnet restore</code></pre>

<p>3. Configure Email Settings</p>
<pre><code>{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "EmailSettings": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Your Name",
    "Email": "your-email", // **تأكد من إدخال الايميل هنا**
    "Password": "your-email-password" // **تأكد من إدخال كلمة المرور هنا**
  }
}</code></pre>
