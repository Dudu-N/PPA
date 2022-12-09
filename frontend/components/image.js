import React from 'react'

const Image = ({ src, alt }) => (
  <img
    draggable={false}
    style={{ width: '100%', height: '100%', position: 'relative' }}
    src={src}
    alt={alt}
  />
)

export default Image