 
Select max(applicationID) ApplicationID,AppTwn-max(applicationID) as TwinID from 
(
SELECT ApplicationID,   ApplicationID+TwinID AppTwn
FROM   Sibblings
)v
Group by AppTwn
 