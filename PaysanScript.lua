-- CECI N'A PAS ÉTË TESTÉ! / THIS WAS NOT TESTED
-- J'ai traduis les variables et rouler, mais pas au complet. Notamment, les instructions avec direction n'ont pas été testée.
-- Merci pour votre compréhension!

COMPTEUR_COMBAT = true
COMPTEUR_RECOLTE = true
OUVRIR_SAC = true
MAX_PODS = 90
ELEMENTS_RECOLTABLE = { 45 } -- Blé(45), Orge(53), Avoine(57),Houblon(46), Lin(50), Malt(58), Riz(159),Seigle(52), Chanvre(54)

function mouvement()
	return
	{
		{  map = "7549", cell = "381"}, -- Dentro banco astrub
		{  map = "7414", cell = "36"}, -- Fuera banco astrub
		{  map = "7413", cell = "21"},
		{  map = "7412", cell = "22"},
		{  map = "7412", cell = "22"},
		{  map = "7411", cell = "TOP"}, -- Zaap astrub
		{  map = "7410", cell = "21"},
		{  map = "7409", cell = "25"},
		{  map = "7408", cell = "347"},
		{  map = "7424", cell = "23"},
		{  map = "7423", cell = "21"},
		{  map = "7422", recolte = true, direction = "TOP|RIGHT"},
		{  map = "7438", recolte = true, direction = "LEFT|TOP"},
		{  map = "7421", recolte = true, direction = "RIGHT|TOP"}, --218 removed here
		{  map = "7405", recolte = true, cell = "231"}, --TOP removed here
		{  map = "7404", recolte = true, cell = "456|231"},
		{  map = "7437", recolte = true, direction = "LEFT|TOP"},
		{  map = "7436", recolte = true, cell = "334"},
		{  map = "7420", recolte = true, cell = "456|218|347"},
		{  map = "7436", recolte = true, cell = "334|456"},
    }
end

function banque()
	return
	{
		{  map = "7404", cell = "456"},
		{  map = "7405", cell = "231"},
		{  map = "7420", cell = "456"},
		{  map = "7436", cell = "456"},
		{  map = "7421", cell = "459"},
		{  map = "7422", cell = "456"},
		{  map = "7423", cell = "458"},
		{  map = "7437", cell = "160"},
		{  map = "7424", cell = "363"},
		{  map = "7408", cell = "460"},
		{  map = "7409", direction = "BOTTOM"},
		{  map = "7410", cell = "457"},
		{  map = "7411", direction = "BOTTOM"}, -- Zaap astrub
		{  map = "7412", cell = "455"},
		{  map = "7413", cell = "456"},
		{  map = "7414", cell = "142"}, -- fuera banco astrub
		{  map = "7549", cell = "381", npc_banque = true}, -- dentro banco astrub
    }
end