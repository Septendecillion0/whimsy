// tutorial contains invalid warrant: wrong date and address. Vampire enters without consent
VAR delay = 3

Can I help you? #VILLAGER #{delay}
Only if your name is Richard Mueller? #VAMPIRE #{delay} 
Yes, that's me. What do you want? #VILLAGER #{delay}
I need to search your house— you're the lead suspect in the case I'm working on. If I don't find anything I'll let you go. #VAMPIRE #{delay}
What? You can't just come into my house. I have rights! #VILLAGER #{delay}
Yeah you have rights, but I have a warrant. #VAMPIRE #{delay} #TUTORIAL_WARRANT

//warrant shown

This document has incorrect information on it! I am not going to let you into my house. #VILLAGER #{delay}
Well, I don't care if you let me or not. I'm going to arrest you for non-compliance! #VAMPIRE #{delay}
The vampire pushes open the door, grabs Richard, and gets ready to haul him off. #NARRATOR #{delay}
Let go of me! #VILLAGER #{delay}

//tutorial interrupt

The villager struggles, but the two of them leave the property. The door is left wide open. #NARRATOR #{delay}

    -> END