import { AppBar, Switch, Toolbar, Typography } from "@mui/material";

interface Props {
  switchTheme: (
    event: React.ChangeEvent<HTMLInputElement>,
    checked: boolean
  ) => void;
}

export default function Header({ switchTheme }: Props) {
  return (
    <AppBar position="static" sx={{ m: 4 }}>
      <Toolbar>
        <Typography variant="h6">CLEAN-SHOP</Typography>
        <Switch onChange={switchTheme} />
      </Toolbar>
    </AppBar>
  );
}
