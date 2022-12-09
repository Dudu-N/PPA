import { Box,Toolbar,Button,Typography,AppBar} from '@mui/material';
import { useRouter } from 'next/router';

export default function Navbar(){

    const router = useRouter();

    const handleLogin = () =>{
      router.push("/login")
    }

    return <Box sx={{ flexGrow: 1 }} >
      <AppBar position="static" style={{ background: 'black', borderBottom: '2px solid white'}}>
        <Toolbar>
        {/* <Image src={'/assets/logos/logo_round.png'} layout="intrinsic" width={75} height={75}/> */}
        
          <Typography variant="h5" sx={{ flexGrow: 1,fontWeight:500,py:2 }} onClick={() => router.push('/')}>
            Pedal Power Association
          </Typography>
          
            <Button
            style={{backgroundColor: '#FFFFFF', color: '#000000',borderRadius:'3rem'}}
            onClick={handleLogin}
            variant="contained"
             >Login/SignUp</Button>
        </Toolbar>
      </AppBar>
    </Box>
}