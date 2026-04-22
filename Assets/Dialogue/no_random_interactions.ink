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
Hey, open up. It's V.A.M.P.I.R.E. #VAMPIRE
What? Who are you? #VILLAGER
It doesn't matter. I have a warrant for your arrest. #VAMPIRE
Can I see it? #VILLAGER
Here it is. #VAMPIRE #WRONG_ADDRESS
Ummm. I don't think I want to let you in. #VILLAGER
Too bad, I've got a warrant! #VAMPIRE
Vampire busts through the door. #VAMPIRE_HUNTS
-> END

=== no_signature ===
#VIOLATION
Hello? It's V.A.M.P.I.R.E, you've gotta let me in. #VAMPIRE
Huh? I didn't do anything wrong. I'm not opening the door! #VILLAGER
I've got a warrant! That means you have to let me in! #VAMPIRE #NO_SIGNATURE
No way! #VILLAGER
Alright, well I didn't want it to come to this. #VAMPIRE
Vampire barges in. #NARRATION #VAMPIRE_HUNTS
-> END

=== impersonating_two ===
#NO_VIOLATION
Hey this is the police. Open up. #VAMPIRE
Oh, you're the police? #VILLAGER
Yep. We have reason to believe a suspect is hiding in your house. #VAMPIRE
What? I don't know anybody that would commit a crime? My family, we're all very law-abiding! #VILLAGER
In that case, just let us in to do a quick sweep. #VAMPIRE
... Okay fine. You'll see none of us have done anything wrong. #VILLAGER
Vampire walks in. #NARRATION
Villager is devoured. #NARRATION #VAMPIRE_HUNTS
-> END

// potentially after this one if its recorded, we can have some sort of text at the end of the day from your boss saying how fucked up it is that this is legal.

=== no_warrant ===
Hey. I'm going to need to come in. #VAMPIRE
Who are you? #VILLAGER
I'm with V.A.M.P.I.R.E. I'm coming in. #VAMPIRE
Wait. Don't you vampires need my permission? #VILLAGER
You think you know V.A.M.P.I.R.E code better than me? #VAMPIRE
Vampire barges in. #NARRATION
The vampire devours the villager! #NARRATION #VAMPIRE_HUNTS
-> END





