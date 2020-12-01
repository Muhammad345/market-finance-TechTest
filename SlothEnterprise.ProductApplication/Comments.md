List of Conern in Code
#1 Clean code rulese 
 public int SubmitApplicationFor(ISellerApplication application)
 above function is handling 3 types of Loan request like
 SelectiveInvoiceDiscount
 ConfidentialInvoiceDiscount
 BusinessLoans

 #2 Lack of Validation 
  as function is hadling 3 types of message but it is not validiting any required data and data format . it can cause run time error if data is 
  missing . Null object error or exception at micro service level . We need to validate and make sure all required data is available before 
  making any call to micro services 

  #3 Lack of Proper error handling 
  if any of dependent call for 3 type of loan failed then it is not handler properly what message need to send to end user in case of Error
  1 SelectiveInvoiceDiscount
  2 ConfidentialInvoiceDiscount
  3 BusinessLoans
  how we can retry if micro service is down due to network failer or few second unresponsive . in that scenario we loss that message and thier is
  no redelivery option in that case .
  I suggest when we need to send data to other API we need to use queue if message failed it will go in deadletter queue so we can retry or we can
  some basic retry functionality 


 #4 Debugging in case of live issue 
 for example user reported some issue during last night around 12:00 am . it is not easy from that code  we can debug what issue was and when issue
 was . It is lack of Debugging suppport and that is crucial for business and manage maintenance 
 Debugging issue is a heart of application if we make our debugging easy then it will be easier for us to support that application while in production


 #5 Not consistent response reply 
 SubmitApplicationFor method return  -1 or Application id number it is not easy to get idea what happen when reply is -1 becuase Applicatio id 
 is nullable and in case of error user do not understand why error happen due and how it can be fixed . -1 is not valid error reason for end user 
 in my point of view we need to add consisten reply response to end user so user can see why my request failed and if it is due to simpliy data 
 then it indicate which data is missing . it also help to reduce unnecessairy call to API

 #6 ProductApplicationService not implenting any interface 
 Testability point of if we build more feature around ProductApplicationService and use in our differnt project as concerte implmenation then it 
 break testability rule because any service who use ProductApplicationService can not mock that implemenation. so we need to add interface if want to 
 exten any more feature around our prodct becuase with the passage of time our feature and code grow which need testabl code .

 #7 Test Coverage 
 I need to write test which will cover negative scenarios like exception , API Throw exception and handler those scenarios in code and cover with 
 Test 
 Integration need to be added for more end to end testing but it all dependent on time and task pripority .

 #Build pipe
 CI pipe and run unit and integration test when each PR created 





