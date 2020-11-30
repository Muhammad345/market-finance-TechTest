List of Conern in Code
#1 Clean code rulese 
 public int SubmitApplicationFor(ISellerApplication application)
 above function is handling 3 types of Loan request like
 SelectiveInvoiceDiscount
 ConfidentialInvoiceDiscount
 BusinessLoans

 #2 Lack of Validation 
  as function is hadling 3 types of message but it is not validiting any required data and data format . it can cause run time error if data is 
  missing . Null object error 

  #3 Lack of Proper error handling 
  if any of dependent call for 3 type of loan failed then it is not handler properly what message need to send to end user in case of Error
  1 SelectiveInvoiceDiscount
  2 ConfidentialInvoiceDiscount
  3 BusinessLoans

 #4 Debugging in case of live issue 
 for example user reported some issue during last night around 12:00 am . it is not easy from that code  we can debug what issue was and when issue
 was . It is lack of Debugging suppport and that is crucial for business and manage maintenance 

 #5 Not consistent response reply 
 SubmitApplicationFor method return  -1 or Application id number it is not easy to get idea what happen when reply is -1 becuase Applicatio id 
 is nullable and in case of error user do not understand why error happen due and how it can be fixed . -1 is not valid error reason for end user 

 #6 ProductApplicationService not implenting any interface 
 Testability point of if we build more feature around ProductApplicationService and use in our differnt project as concerte implmenation then it 
 break testability rule because any service who use ProductApplicationService can not mock that implemenation. so we need to add interface if want to 
 exten any more feature around our prodct becuase with the passage of time our feature and code grow which need testabl code .




