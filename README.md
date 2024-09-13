# .NET Email Sending

A .NET example for sending emails using MailKit and MimeKit. This project demonstrates how to:

*   Send basic email messages
*   Attach files
*   Send HTML content

## 🧐 Features

Here are some of the project's best features:

*   Easy-to-follow examples
*   Asynchronous email sending

## 🛠️ Installation Steps:

1. **Clone the Repository**

    ```bash
    git clone https://github.com/ziadhanii/sending-emails-with-mailkit-and-mimekit.git
    ```

2. **Install Dependencies**

    ```bash
    dotnet restore
    ```

3. **Configure Email Settings**

    Update the `appsettings.json` file with your email server details:

    ```json
    {
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
        "Email": "your-email", // **Ensure to enter your email here**
        "Password": "your-email-password" // **Ensure to enter your password here**
      }
    }
    ```

## 📸 Screenshot

Here is a screenshot of the project:

![Screenshot](Screenshot%202024-09-13%20044231.png "Screenshot")
