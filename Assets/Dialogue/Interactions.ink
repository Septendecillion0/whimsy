VAR delay = 3

-> impersonating


=== impersonating ===
//Diaologue with impersonating police officer ruse
//Always will be a fake warrant
Vampire: I’m looking for a suspect named Seymour Orion in this crime. #VAMPIRE #{delay}
Vampire: TESTING #VAMPIRE
Villager: Umm, I don’t know anybody named Seymour Orion… What did he do? #VILLAGER #{delay}
Vampire: I’m going to need to search your house to find him. We have a warrant. Can I come in? #VAMPIRE #FAKE_WARRANT #{delay}

Villager: {~ -> consent | -> no_consent}

= consent 
Oh. Okay. Fine, you can come in.
    -> no_violation

= no_consent
I don’t know. I still don’t want you coming inside. 
{~ -> violation| -> no_violation} #NARRATION #{delay}

= violation
#VIOLATION #{delay}
Vampire barges into the house.
    -> END

= no_violation
#NO_VIOLATION #{delay}
{no_consent: Vampire decides to leave.}
{consent: The vampire walks in.}
    -> END