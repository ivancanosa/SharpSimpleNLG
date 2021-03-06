﻿/*
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations
 * under the License.
 *
 * The Original Code is "SharpSimpleNLG".
 *
 * The Initial Developer of the Original Code is Ehud Reiter, Albert Gatt and Dave Westwater.
 * Portions created by Ehud Reiter, Albert Gatt and Dave Westwater are Copyright (C) 2010-11 The University of Aberdeen. All Rights Reserved.
 *
 * Contributor(s): Ehud Reiter, Albert Gatt, Dave Wewstwater, Roman Kutlak, Margaret Mitchell, Saad Mahamood, Nick Hodge
 */

/* Additional Notes:
 *    - Original Java source is SimpleNLG from 12-Jun-2016 https://github.com/simplenlg/simplenlg
 *    - This is a port of the Java version to C# with no additional features
 *    - I have left the "Initial Developer" section to reflect this fact
 *    - Any questions, comments, feedback on this port can be sent to Nick Hodge <nhodge@mungr.com>
 */

using System;
using System.Collections.Generic;
using SimpleNLG;

namespace SharpSimpleNLGConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ss = new XMLLexicon();
            var Factory = new NLGFactory(ss);
            var Realiser = new Realiser(ss);

            // Instructions will be given to you by the director.

            var verbp = Factory.createVerbPhrase("be given");
            verbp.setFeature(Feature.TENSE.ToString(), Tense.FUTURE);
            var subj = Factory.createNounPhrase("The Director");
            var oobj = Factory.createNounPhrase("Instruction");
            var ioobj = Factory.createNounPhrase("you");
            subj.setPlural(false);
            oobj.setPlural(true);

            var s = new List<INLGElement>() { verbp, subj, oobj, ioobj };

            var clause = Factory.createClause();

            clause.setVerb(verbp);
            clause.setSubject(subj);
            clause.setObject(oobj);
            clause.setIndirectObject(ioobj);
            

            var sentence = Factory.createSentence(clause);
            sentence.setFeature(Feature.TENSE.ToString(), Tense.FUTURE);

            var active = Realiser.realise(sentence).ToString();

            Console.WriteLine($"{active}");

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
