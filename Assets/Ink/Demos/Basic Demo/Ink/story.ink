
It's 6:15am. You're at home with your three children and your wife. You're an undocumented immigrant who has been in the US for over 20 years. There's a knocking at the door.
+ [Look through the peephole]
    -> agent_description
+ [Stay silent]
    -> agent_convo


=== agent_description ===
Six men in plainclothes stand outside.
They bang on the door again.
    -> agent_convo

=== agent_convo ===
"Open up! It's the NYPD. We're looking for a suspect in an open criminal case" One says.
Another holds up a photo. "Have you seen this man?"
You don't know who this is.
Your 15 year old wakes up and asks what's going on.
You tell them to go back to sleep. 
The men bang on the door loudly again.
You hear your other kids waking up.
+ ["We've never seen that man."]
+ [Stay silent.]
- "We need to come inside to verify the suspect isn't hiding in the home," the men say.
"Okay, okay." Your wife says. "Let's just let them in. They said they're NYPD, and when they realize we don't have anything to do with their case they'll leave us alone."
+ [Open the door.]
    -> entered_ending
+ [Stay silent.]
- "We're not leaving until you open up!" They shout.
+ [Open the door.]
    -> entered_ending
+ [Stay silent.]
- The men stand outside your door for another twenty minutes until they eventually leave.
...
    -> END



=== entered_ending ===
You open the door, and the men push their way inside. Instead of looking around your house for the suspect, they ask you for your ID. They ask how long you've been in the U.S.
+ [Stay silent.]
"We're the NYPD. Answer our questions."
+ [Answer.]
You answer.
- One of the men grabs your wrists and starts cuffing them.
"Why are you arresting him?"
"We're here under the authority of ICE," they say. They pull out your husband's photo which had been hidden underneath the photo of the suspect from earlier. "Bring some cash for the subway fare home. We're just investigating an incident. You'll be released later."
You take $20 from your wallet.
You don't return home.
...
    -> END