using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Question
    {
        private int sessionNumber;

        public int SessionNumber
        {
            get { return SessionNumber; }
            set { SessionNumber = value; }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        private int receivedQues;

        public int ReceivedQues
        {
            get { return receivedQues; }
            set { receivedQues = value; }
        }
        private int IoppositionQues;

        public int IoppositionQues1
        {
            get { return IoppositionQues; }
            set { IoppositionQues = value; }
        }
        private int govtQues;

        public int GovtQues
        {
            get { return govtQues; }
            set { govtQues = value; }
        }
        private int repliedQues;

        public int RepliedQues
        {
            get { return repliedQues; }
            set { repliedQues = value; }
        }
        private int disallowedQues;

        public int DisallowedQues
        {
            get { return disallowedQues; }
            set { disallowedQues = value; }
        }
        private int lapsedQues;

        public int LapsedQues
        {
            get { return lapsedQues; }
            set { lapsedQues = value; }
        }



    }
}
