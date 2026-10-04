 function CallMe(divid,group,sess,memid,catid)
 {     
     var divis = document.getElementById(divid);
     var sessid = document.getElementById(sess);
     var mid = document.getElementById(memid);
     var cid = document.getElementById(catid);

     // call server side method
     PageMethods.GetContactName(divis.value, CallSuccess, CallFailed, group,sessid,mid,catid);
 }

 // set the destination textbox value with the ContactName
 function CallSuccess(res, destCtrl)
 {     
     var dest = document.getElementById(destCtrl);
     dest.value = res;
 }

 // alert message on some failure
 function CallFailed(res, destCtrl)
 {
     alert(res.get_message());
 }

