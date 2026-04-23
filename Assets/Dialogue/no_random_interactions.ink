VAR delay = 3

=== impersonating ===
#VIOLATION
#WRONG_WARRANT
I’m looking for a suspect named Seymour Orion in this crime. #VAMPIRE
Umm, I don’t know anybody named Seymour Orion… What did he do? #VILLAGER
I’m going to need to search your house to find him. We have a warrant. Can I come in? #VAMPIRE #WARRANT
I don't know. I still don't want you coming inside #VILLAGER
Vampire barges into the house. #NARRATION #VAMPIRE_HUNTS
Nice work, you reported a code violation. He showed an arrest warrant and not a search warrant. #FEEDBACK_SUCCESS
You seemed to have missed a violation. He showed an arrest warrant instead of a search warrant. #FEEDBACK_FAIL
-> END

=== wrong_address ===
#VIOLATION
#ADDRESS: 1000 Bloodsucker Lane
Hey, open up. It's V.I.L.E. #VAMPIRE
What? Who are you? #VILLAGER
It doesn't matter. I have a warrant for your arrest. #VAMPIRE
Can I see it? #VILLAGER
Here it is. #VAMPIRE #WARRANT
Ummm. I don't think I want to let you in. #VILLAGER
Too bad, I've got a warrant! #VAMPIRE
Vampire busts through the door. #VAMPIRE_HUNTS
Good job. You correctly reported a violation. The address on the warrant was incorrect. #FEEDBACK_SUCCESS
You missed a violation: The address on the warrant was wrong. #FEEDBACK_FAIL
-> END

=== no_signature ===
#VIOLATION
#NO_SIGNATURE
Hello? It's V.I.L.E, you've gotta let me in. #VAMPIRE
Huh? I didn't do anything wrong. I'm not opening the door! #VILLAGER
I've got a warrant! That means you have to let me in! #VAMPIRE #WARRANT
No way! #VILLAGER
Alright, well I didn't want it to come to this. #VAMPIRE
Vampire barges in. #VAMPIRE_HUNTS
You correctly identified a violation. That warrant was missing a signature. #FEEDBACK_SUCCESS
Looks like you missed a violation. The warrant was missing a signature. #FEEDBACK_FAIL

-> END

=== impersonating_two ===
#NO_VIOLATION
Hey this is the police. Open up. #VAMPIRE
Oh, you're the police? #VILLAGER
Yep. We have reason to believe a suspect is hiding in your house. #VAMPIRE
What? I don't know anybody that would commit a crime? My family, we're all very law-abiding! #VILLAGER
In that case, just let us in to do a quick sweep. #VAMPIRE
... Okay fine. You'll see none of us have done anything wrong. #VILLAGER
Vampire walks in.
Villager is devoured. #VAMPIRE_HUNTS
You're right, there was no violation in this case. It's pretty awful that they're allowed to just lie about who they are, but that's how the law is right now. #FEEDBACK_SUCCESS
You reported that one. Good instincts, but unfortunately it's somehow totally legal for them to impersonate police officers. #FEEDBACK_FAIL

-> END

=== no_warrant ===
#VIOLATION
Hey. I'm going to need to come in. #VAMPIRE
Who are you? #VILLAGER
I'm with V.I.L.E. I'm coming in. #VAMPIRE
Wait. Don't you vampires need my permission? #VILLAGER
You think you know V.I.L.E code better than me? #VAMPIRE
Vampire barges in.
The vampire devours the villager. #VAMPIRE_HUNTS
Nice work, you correctly reported that violation. They definitely need a warrant to come into your house without consent. #FEEDBACK_SUCCESS
Seems you missed a violation. That vampire needed a warrant to barge in there.
-> END

=== wrong_date ===
#VIOLATION
#DATE: April 10, 2026
Hello villager. We have a warrant to come in. #VAMPIRE
What? A search warrant? #VILLAGER
Yes. Here it is. #WARRANT #VAMPIRE
Um. I still don't really want you coming in. #VILLAGER
Vampire breaks down the door and barges in.
The vampire devours the villager. #VAMPIRE_HUNTS
Good catch. The date on that warrant was expired: They have to have a date that's before or the same as the current date. #FEEDBACK_SUCCESS
Be careful. You missed a violation. The date on that warrant was expired: They have to have a date that's before or the same as the current date. #FEEDBACK_FAIL
-> END

=== impersonating_three ===
#NO_VIOLATION
This is the police. We're here about an issue with your car. #VAMPIRE
Huh? What's wrong with my car? #VILLAGER
We need to see your registration. #VAMPIRE
Oh. Maybe there was some problem with the paperwork? #VILLAGER
Can you show us your registration? #VAMPIRE
Yeah. It's in my car, I can go get it. #VILLAGER
Villager steps out of their home. #VILLAGER
Actually! We're V.I.L.E. #VAMPIRE
Villager is devoured. #VAMPIRE_HUNTS
You're right there's no violation. We can't report a "violation" in this case because its legal for them to impersonate the police and lie like that. #FEEDBACK_SUCCESS
Unfortunately, we can't report a "violation" in this case because its legal for them to impersonate the police and lie like that. #FEEDBACK_FAIL
-> END

=== impersonating_four ===
#NO_VIOLATION
We're conducting an investigation. Can we ask you some questions? #VAMPIRE
Oh. Are you police? #VILLAGER
... Yes. #VAMPIRE
Um. Okay. I guess you can come in for a little bit. #VILLAGER
Vampire walks in.
We're a part of V.I.L.E. You're going to be eaten now. #VAMPIRE
Villager is devoured. #VAMPIRE_HUNTS
That's right, there's no violation. We can't report a "violation" in this case because its legal for them to impersonate the police and just make stuff up. #FEEDBACK_SUCCESS
Unfortunately, we can't report a "violation" in this case because its legal for them to impersonate the police and lie like that. #FEEDBACK_FAIL
-> END

=== health_impersonation ===
#VIOLATION
Hey we're health inspectors, and we need to check out your home. #VAMPIRE
Oh man. Is there something wrong. #VILLAGER
Well we've gotta enter to check it out. #VAMPIRE
Okay. Okay well come on in. #VILLAGER
Vampire walks in.
I'm actually V.I.L.E. #VAMPIRE
Villager is devoured. #VAMPIRE_HUNTS
Good work. Even if they're allowed to impersonate police, V.I.L.E. is not allowed to pretend to be health and safety workers. #FEEDBACK_SUCCESS
I think you missed a violation. Even if they're allowed to impersonate police, V.I.L.E. is not allowed to pretend to be health and safety workers. #FEEDBACK_FAIL
-> END

=== wrong_warrant ===
#VIOLATION
#WRONG_WARRANT
Open up, it's V.I.L.E. We've got a warrant. #VAMPIRE
V.I.L.E.? I'm not letting you in! Show me your warrant! #VILLAGER
Here it is. #WARRANT #VAMPIRE
Ummmm, I still don't consent to letting you in! #VILLAGER
Too bad, our warrant lets us come in. #VAMPIRE
Vampire barges in.
Villager is devoured. #VAMPIRE_HUNTS
Good eye. This is an arrest warrant, not a search warrant. #FEEDBACK_SUCCESS
Careful. You missed a violation. That's an arrest warrant, not a search warrant. #FEEDBACK_FAIL
-> END

=== wrong_date_no_violation ===
#VIOLATION
#ADDRESS: 17 Dracula Alley
Hey, open up. It's V.I.L.E. #VAMPIRE
Who? #VILLAGER
It doesn't matter. I have a warrant to search your house. #VAMPIRE
Can I see it? #VILLAGER
Here it is. #VAMPIRE #WARRANT
Oh man. Okay. I suppose you can come in... #VILLAGER
Vampire enters. 
The villager is devoured. #VAMPIRE_HUNTS
Good catch. In order to be a valid warrant, the address needs to be correct. #FEEDBACK_SUCCESS
You missed a violation. The address was wrong on that one, making it a valid warrant. #FEEDBACK_FAIL
-> END

=== you_won ===
#VIOLATION
#WRONG_WARRANT
Congratulations resident! You were randomly selected to win a prize. #VAMPIRE
Huh? What did I do? #VILLAGER
In order to claim your prize, you need to let me in. #VAMPIRE
Wait, aren't you with V.I.L.E.? I'm not letting you in. #VILLAGER
Don't be ridiculous, I can do anything with this warrant! #VAMPIRE #WARRANT
Vampire pushes their way in. #NARRATION
Villager is devoured #VAMPIRE_HUNTS
It's good you caught that violation. That wasn't a search warrant he showed. #FEEDBACK_SUCCESS
Seems you missed a violation. He showed an arrest warrant, not a search warrant. #FEEDBACK_FAIL
->END

=== bag_search ===
#NO_VIOLATION
Good evening ma'am, I believe that you may have recently picked up a bag similar to your own on accident. #VAMPIRE
Oh no! Do you have mine then? #VILLAGER
Yes, but you have to let me search for the bag to make sure that all of the contents remain before we can return yours. #VAMPIRE
Oh my, here let me show you to my bags. #VILLAGER
The vampire is let in. #NARRATION
Villager is devoured. #VAMPIRE_HUNTS
You're right, there wasn't any violation there. Isn't it crazy that they're allowed to lie about stuff like that? #FEEDBACK_SUCCESS
It's awful, but there technically wasn't a violation there. It's crazy that they're just allowed to lie about stuff like that though. #FEEDBACK_FAIL
->END

=== no_bag ===
#VIOLATION
#DATE: March 30, 2026
Hello sir, I believe you may have taken someone else's bag today and I am here to look for it. #VAMPIRE
Bag? I didn't go shopping today. What are you trying to pull? #VILLAGER
Nothing, I'm here to search your house and I have a warrant. #VAMPIRE
What? I don't trust you so I'm not letting you in, papers or not. #VILLAGER
Grave mistake! I'll show you what happens when you cross V.I.L.E.! #VAMPIRE
Vampire walks in. #NARRATION
Villager is devoured. #VAMPIRE_HUNTS
Good work. That warrant was totally out of date. #FEEDBACK_SUCCESS
Watch out. You missed a violation. That warrant was totally out of date. #FEEDBACK_FAIL

->END 

