toBeNamed := function(direction, location, order, root, orient1, orient2)
	local d := direction + orient2; # Assume direction is scrubbed for now. 
	local sign;
	sign := 1 - orient1;
	return build(d, order, sign);
end;

build := function(d, N, s)
	local product := E(2*N)^(2*d+1);
	if s = -1 then
		product := -product^-1;
	fi;
	product := product * (E(2*N) + E(2*N)^-1);
	return product;
end;
