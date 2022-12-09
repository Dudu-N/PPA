import React from 'react';
import {Box} from '@mui/material'

interface CenterBoxProps{
    children: any
}
export default function CenterBox(props: CenterBoxProps){
    return (
        <div>
             <Box 
                sx={{
                p:2,
                display: 'flex',
                justifyContent: 'center',
                flexWrap:'wrap',
                backgroundColor:'black',
                color:'white'}} >
                    {props.children}
            </Box>
        </div>
    );
}

