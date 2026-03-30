VAR delay = 3

-> impersonating

=== violation ===
Vampire barges into the house. #VIOLATION #{delay}
    -> END

=== no_violation ===
Vampire decides to leave. #NO_VIOLATION
    -> END

=== impersonating ===
Vampire: I’m looking for a suspect named Seymour Orion in this crime. #VAMPIRE #{delay}
Villager: Umm, I don’t know anybody named Seymour Orion… What did he do? #VILLAGER #{delay}
Vampire: I’m going to need to search your house to find him. We have a warrant. Can I come in? #VAMPIRE #{delay}
{~He shows a fake warrant.|He shows a real warrant.} #NARRATION #{delay}

Villager: {~Oh. Okay. Fine, you can come in.|I don’t know. I still don’t want you coming inside.} #VAMPIRE #{delay}

{~ -> violation| -> no_violation} #NARRATION #{delay}




