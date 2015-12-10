# IP Messaging Quickstart for C# (ASP.NET MVC)

This application should give you a ready-made starting point for writing your
own messaging apps with Twilio IP Messaging. Before we begin, we need to collect
all the config values we need to run the application:

| Config Value  | Description |
| :-------------  |:------------- |
Service Instance SID | Like a database for your IP Messaging data - [generate one in the console here](https://www.twilio.com/user/account/ip-messaging/services)
Account SID | Your primary Twilio account identifier - find this [in the console here](https://www.twilio.com/user/account/ip-messaging/getting-started).
API Key | Used to authenticate - [generate one here](https://www.twilio.com/user/account/ip-messaging/dev-tools/api-keys).
API Secret | Used to authenticate - [just like the above, you'll get one here](https://www.twilio.com/user/account/ip-messaging/dev-tools/api-keys).

## A Note on API Keys

When you generate an API key pair at the URLs above, your API Secret will only
be shown once - make sure to save this in a secure location, 
or possibly your system environment variables.

## Setting Up The Application

After downloading the repo, copy the `TwilioIpMessaging/Web.config.example` to
`Web.config` in the same directory. Next, open up `TwilioIpMessaging.sln` in
Visual Studio.  Edit `Web.config` with the four values we obtained above:

```xml
<appSettings>
	<add key="TwilioAccountSid" value="ACxxx" />
	<add key="TwilioApiKey" value="SKxxx" />
	<add key="TwilioApiSecret" value="xxxxxxxx" />
	<add key="TwilioIpmServiceSid" value="ISxxxx" />
</appSettings>
```

You should now be ready to rock! Hit `F5` or the Play button, and you should 
land on the home page of our basic chat application. Open it up in a few browser
tabs and start chatting with yourself!

![screenshot of chat app](https://s3.amazonaws.com/howtodocs/quickstart/ipm-browser-quickstart.png)

## License

MIT
