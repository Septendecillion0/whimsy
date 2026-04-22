VAR delay = 3

=== impersonating ===
#VIOLATION
I’m looking for a suspect named Seymour Orion in this crime. #VAMPIRE #{delay}
Umm, I don’t know anybody named Seymour Orion… What did he do? #VILLAGER #{delay}
I’m going to need to search your house to find him. We have a warrant. Can I come in? #VAMPIRE #FAKE_WARRANT #{delay}
I don't know. I still don't want you coming inside #VILLAGER
Vampire barges into the house. #NARRATION #VAMPIRE_HUNTS
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
-> END

// potentially after this one if its recorded, we can have some sort of text at the end of the day from your boss saying how fucked up it is that this is legal.

=== no_warrant ===
#VIOLATION
Hey. I'm going to need to come in. #VAMPIRE
Who are you? #VILLAGER
I'm with V.I.L.E. I'm coming in. #VAMPIRE
Wait. Don't you vampires need my permission? #VILLAGER
You think you know V.I.L.E code better than me? #VAMPIRE
Vampire barges in.
The vampire devours the villager. #VAMPIRE_HUNTS
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
-> END

=== wrong_warrant ===
#WRONG_WARRANT
Open up, it's V.I.L.E. We've got a warrant. #VAMPIRE
V.I.L.E.? I'm not letting you in! Show me your warrant! #VILLAGER
Here it is. #WARRANT #VAMPIRE
Ummmm, I still don't consent to letting you in! #VILLAGER
Too bad, our warrant lets us come in. #VAMPIRE
Vampire barges in.
Villager is devoured. #VAMPIRE_HUNTS
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
-> END
