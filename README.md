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

 ![alt text][Doc1]
 ![alt text][Doc2]
 ![alt text][Doc3]
 ![alt text][Doc5]
 ![alt text][Doc4]

[Doc1]: ./Docs/Mainform.png "Main form"
[Doc2]: ./Docs/Settings.png "Settings dialog"
[Doc3]: ./Docs/Settings2.png "Settings dialog"
[Doc4]: ./Docs/Notification.png "Notification area pop-up"
[Doc5]: ./Docs/IEFOnboarding.png "IEF Onboarding dialog"