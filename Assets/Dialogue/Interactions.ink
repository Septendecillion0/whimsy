VAR delay = 3

-> impersonating


=== impersonating ===
//Diaologue with impersonating police officer ruse
//Always will be a fake warrant
I’m looking for a suspect named Seymour Orion in this crime. #VAMPIRE #{delay}
Umm, I don’t know anybody named Seymour Orion… What did he do? #VILLAGER #{delay}
I’m going to need to search your house to find him. We have a warrant. Can I come in? #VAMPIRE #FAKE_WARRANT #{delay}

{~ -> consent | -> no_consent}

= consent 
Oh. Okay. Fine, you can come in. #VILLAGER
    -> no_violation

= no_consent
I don’t know. I still don’t want you coming inside. #VILLAGER
{~ -> violation| -> no_violation} #NARRATION #{delay}

= violation
#VIOLATION #{delay}
Vampire barges into the house. #VAMPIRE_HUNTS
    -> END

= no_violation
#NO_VIOLATION #{delay}
{no_consent: Vampire decides to leave. #VAMPIRE_LEAVES}
{consent: The vampire walks in. #VAMPIRE_HUNTS}
    -> END