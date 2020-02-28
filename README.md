# B2CDevSync

Facilitates rapid development of B2C Identity Experience Framework (IEF) policies and custom UI content. 
As files are saved locally, this utility notices the change and pushes UI content to a designated Azure Storage Account, 
or in the case of a policy, it uses the new (preview) Azure AD B2C management API to update the policy in your tenant. 

See the sample code at https://github.com/Azure-Samples/active-directory b2c-graph-trustframework-policy for more information 
on the feature.

Saves multiple profiles, so you can store settings for different projects (a "profile" here would be a set of policies along with associated 
custom UI). All projects will need to be associated with the same Azure AD B2C tenant for now.

<a href='Install/B2CDevSync.zip?raw=true'> Download binaries</a>

__NEW:__

An experimental feature has been added that automates the process of onboarding a new B2C tenant with the Identity Experience Framework. The steps
in the document at https://docs.microsoft.com/en-us/azure/active-directory-b2c/custom-policy-get-started have been wired up via REST. The SocialAndLocalAccounts
sample policies have been tested. The B2C Test App creation routine uses a combination of calls to correctly enable the app and its associated
service principal for the B2C environment.

To onboard, click the Init Tenant button on the main screen after logging in. A dialog will open with all the controls for this operation. Click Get Status to query
the tenant and determine which items need to be implemented. The list of items on the right should be clicked one by one from the top down - each button carries out 
a task from the document above. 

The Pull Repo button will download a ZIP archive from the custom policy starterpack GitHub repo at https://github.com/Azure-Samples/active-directory-b2c-custom-policy-starterpack.
This repo will be extracted and copies will be made depending on the pack selected (as mentioned, only SocialAndLocalAccounts have been tested).

Once all the steps have been completed (setting up Facebook as an external identity provider still needs to be done in the Facebook developer portal, although this tool
will capture the appid and secret), the Create button will be enabled. Click it and the selected pack will be copied, values in the templates will be updated, and
the files will be uploaded to the B2C tenant.

 ![alt text][Main]
 ![alt text][Settings1]
 ![alt text][Popup]
 ![alt text][IEFOnboarding]

__Setup__

A native app registration in your B2C tenant is required to use this app. An appid and replyURL is configured in the repo, but you should consider creating your own. Here are the steps:
1. Go to the Azure Active Directory blade (NOT the B2C blade) in your B2C tenant
2. Click App registrations (preview) and click New Registration
3. Give it a name, accepting the defaults, and click Register
4. After it's created, click "Authentication" and click "+ Add a platform"
 
![alt text][Auth1]

5. Select Mobile and desktop applications
 
![alt text][Auth2]

6. Select the preconfigured option for nativeclient, or enter your own URI
 
![alt text][Auth3]

7. After that's saved, select API Permissions under Manage, and click "+ Add a permission". Choose Microsoft Graph, Delegated.
 
![alt text][Perm1]

8. Select the following permissions:
  a. Directory.AccessAsUser.All
  b. Policy.ReadWrite.TrustFramework
  c. TrustFrameworkKeySet.ReadWrite.All
 
![alt text][Perm2]

9. Update Application settings, entering the Sync App ID and Redirect URI values from above
 
![alt text][Settings2]

10. Click login on the main form, and consent to these permissions to login to the app
 
![alt text][Perm3]

[Main]: ./Docs/Mainform.png "Main form"
[Settings1]: ./Docs/Settings.png "Settings dialog"
[Settings2]: ./Docs/Settings2.png "Settings dialog"
[Popup]: ./Docs/Notification.png "Notification area pop-up"
[IEFOnboarding]: ./Docs/IEFOnboarding.png "IEF Onboarding dialog"
[Auth1]: ./Docs/auth1.png "IEF Onboarding dialog"
[Auth2]: ./Docs/Auth2.png "IEF Onboarding dialog"
[Auth3]: ./Docs/auth3.png "IEF Onboarding dialog"
[Perm1]: ./Docs/Permissions1.png "IEF Onboarding dialog"
[Perm2]: ./Docs/Permission2.png "IEF Onboarding dialog"
[Perm3]: ./Docs/Permissions3.png "IEF Onboarding dialog"
