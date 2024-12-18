import { AppBar, Toolbar, Typography } from "@mui/material";

export default function Header() {
  return (
    <AppBar position="static" sx={{ m: 4 }}>
      <Toolbar>
        <Typography variant="h6">CLEAN-SHOP</Typography>
      </Toolbar>
    </AppBar>
  );
}
